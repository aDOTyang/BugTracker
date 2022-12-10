<?php $__env->startSection('title'); ?>ChartJS Chart
 <?php echo e($title); ?>

<?php $__env->stopSection(); ?>

<?php $__env->startPush('css'); ?>
<?php $__env->stopPush(); ?>

<?php $__env->startSection('content'); ?>
	<?php $__env->startComponent('components.breadcrumb'); ?>
		<?php $__env->slot('breadcrumb_title'); ?>
			<h3>ChartJS Chart</h3>
		<?php $__env->endSlot(); ?>
		<li class="breadcrumb-item">Charts</li>
		<li class="breadcrumb-item active">ChartJS Chart</li>
	<?php echo $__env->renderComponent(); ?>
	
	<div class="container-fluid">
		<div class="row">
			<div class="col-xl-6 col-md-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Bar Chart</h5>
					</div>
					<div class="card-body chart-block">
						<canvas id="myBarGraph"></canvas>
					</div>
				</div>
			</div>
			<div class="col-xl-6 col-md-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Line Graph</h5>
					</div>
					<div class="card-body chart-block">
						<canvas id="myGraph"></canvas>
					</div>
				</div>
			</div>
			<div class="col-xl-6 col-md-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Radar Graph</h5>
					</div>
					<div class="card-body chart-block">
						<canvas id="myRadarGraph"></canvas>
					</div>
				</div>
			</div>
			<div class="col-xl-6 col-md-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Line Chart</h5>
					</div>
					<div class="card-body chart-block">
						<canvas id="myLineCharts"></canvas>
					</div>
				</div>
			</div>
			<div class="col-xl-6 col-md-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Doughnut Chart</h5>
					</div>
					<div class="card-body chart-block chart-vertical-center">
						<canvas id="myDoughnutGraph"></canvas>
					</div>
				</div>
			</div>
			<div class="col-xl-6 col-md-12 box-col-12">
				<div class="card">
					<div class="card-header pb-0">
						<h5>Polar Chart</h5>
					</div>
					<div class="card-body chart-block chart-vertical-center">
						<canvas id="myPolarGraph"></canvas>
					</div>
				</div>
			</div>
		</div>
	</div>	
	
	<?php $__env->startPush('scripts'); ?>
	<script src="<?php echo e(asset('assets/js/chart/chartjs/chart.min.js')); ?>"></script>
    <script src="<?php echo e(asset('assets/js/chart/chartjs/chart.custom.js')); ?>"></script>
	<?php $__env->stopPush(); ?>

<?php $__env->stopSection(); ?>
<?php echo $__env->make('layouts.admin.master', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/webiotspc/Desktop/hetvi/laravel/Viho-Laravel-8/theme/resources/views/admin/charts/chartjs.blade.php ENDPATH**/ ?>