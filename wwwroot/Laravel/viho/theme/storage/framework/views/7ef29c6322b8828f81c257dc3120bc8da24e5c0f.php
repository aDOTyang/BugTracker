<?php $__env->startSection('title'); ?>Morris Chart
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
			<h3>Morris Chart</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Charts</li>
		<li class="breadcrumb-item active">Morris Chart</li>
	<?php echo $__env->renderComponent(); ?>
	
	<div class="container-fluid">
		<div class="row">
			<div class="col-lg-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Line Chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="morris-line-chart"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Updating Data</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="updating-data-morris-chart"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Decimal Data</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder float-start" id="decimal-morris-chart"></div>
							<p class="float-end" id="choices"></p>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Displaying X Labels Diagonally</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="x-Labels-Diagonally-morris-chart"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Bar Line Chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="bar-line-chart-morris"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Displaying X Labels Diagonally(Bar Chart)</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="x-lable-morris-chart"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Stacked Bars Chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="stacked-bar-chart"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Simple Bar Charts</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="morris-simple-bar-chart"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Area charts behaving like line Charts</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="graph123"></div>
						</div>
					</div>
				</div>
			</div>
			<div class="col-lg-6 col-sm-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Donut Color Chart</h5>
					</div>
					<div class="card-body chart-block">
						<div class="flot-chart-container">
							<div class="flot-chart-placeholder" id="donut-color-chart-morris"></div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>	
	
	<?php $__env->startPush('scripts'); ?>
	<script src="<?php echo e(asset('assets/js/chart/morris-chart/raphael.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/chart/morris-chart/morris.js')); ?>"> </script>
    <script src="<?php echo e(asset('assets/js/chart/morris-chart/prettify.min.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/chart/morris-chart/morris.min.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/chart/morris-chart/morris-script.js')); ?>"></script>
	<?php $__env->stopPush(); ?>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/webiotspc/Desktop/hetvi/laravel/Viho-Laravel-8/theme/resources/views/admin/charts/chart-morris.blade.php ENDPATH**/ ?>