<?php $__env->startSection('title'); ?>Apex Chart
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
			<h3>Apex Chart</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Charts</li>
		<li class="breadcrumb-item active">Apex Chart</li>
	<?php echo $__env->renderComponent(); ?>
	
	<div class="container-fluid">
		<div class="row">
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Basic Area Chart</h5>
					</div>
					<div class="card-body">
						<div id="basic-apex"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Area Spaline Chart</h5>
					</div>
					<div class="card-body">
						<div id="area-spaline"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Bar chart</h5>
					</div>
					<div class="card-body">
						<div id="basic-bar"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Column Chart</h5>
					</div>
					<div class="card-body">
						<div id="column-chart"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>
							3d Bubble Chart
						</h5>
					</div>
					<div class="card-body">
						<div id="chart-bubble"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Candlestick Chart</h5>
					</div>
					<div class="card-body">
						<div id="candlestick"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Stepline Chart</h5>
					</div>
					<div class="card-body">
						<div id="stepline"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Column Chart</h5>
					</div>
					<div class="card-body">
						<div id="annotationchart"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Pie Chart</h5>
					</div>
					<div class="card-body apex-chart">
						<div id="piechart"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Donut Chart</h5>
					</div>
					<div class="card-body apex-chart">
						<div id="donutchart"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Mixed Chart</h5>
					</div>
					<div class="card-body">
						<div id="mixedchart"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Radar Chart</h5>
					</div>
					<div class="card-body">
						<div id="radarchart"></div>
					</div>
				</div>
			</div>
			<div class="col-sm-12 col-xl-6 box-col-6">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Radial Bar Chart</h5>
					</div>
					<div class="card-body">
						<div id="circlechart"></div>
					</div>
				</div>
			</div>
		</div>
	</div>
	
	
	<?php $__env->startPush('scripts'); ?>
	<script src="<?php echo e(asset('assets/js/chart/apex-chart/apex-chart.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/chart/apex-chart/stock-prices.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/chart/apex-chart/chart-custom.js')); ?>"></script>
	<?php $__env->stopPush(); ?>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/webiotspc/Desktop/hetvi/laravel/Viho-Laravel-8/theme/resources/views/admin/charts/chart-apex.blade.php ENDPATH**/ ?>